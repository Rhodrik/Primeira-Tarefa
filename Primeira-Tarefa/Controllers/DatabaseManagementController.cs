using DbUp;
using DbUp.Engine;
using Microsoft.AspNetCore.Mvc;
using Primeira_Tarefa.Constant;
using System.Reflection;

namespace Primeira_Tarefa.Controllers
{
    public class DatabaseManagementController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DatabaseManagementController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPut]
        [Route("mark-as-updated")]
        public async Task<ActionResult> MarkAsUpdatedDatabase()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionString.Postgres);
            DatabaseUpgradeResult result = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(
                    assembly: Assembly.GetExecutingAssembly(),
                    filter: (s) => s.Contains($".Scripts.Client."))
                .JournalToPostgresqlTable("first_task", "__migrations")
                .LogToAutodetectedLog()
                .WithTransactionPerScript()
                .Build()
                .MarkAsExecuted();

            if (result.Successful)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Error);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateDatabase()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionString.Postgres);
            DatabaseUpgradeResult result = DeployChanges.To
                .PostgresqlDatabase(connectionString, "first_task")
                .WithScriptsEmbeddedInAssembly(
                    assembly: Assembly.GetExecutingAssembly(),
                    filter: (s) => s.Contains($".Scripts.Client"))
                .JournalToPostgresqlTable("first_task", "__migrations")
                .LogToAutodetectedLog()
                .WithTransactionPerScript()
                .Build()
                .PerformUpgrade();

            if (result.Successful)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Error);
            }
        }
    }
}