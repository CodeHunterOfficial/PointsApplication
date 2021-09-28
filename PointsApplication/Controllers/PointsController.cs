using Dapper;
using Microsoft.AspNetCore.Mvc;
using PointsApplication.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PointsApplication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly ConnectionStrings _con;
        public PointsController(ConnectionStrings con)
        {
            _con = con;
        }
        // GET: api/v1/points
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.Run(() =>
            {
                using (var c = new MySqlConnector.MySqlConnection(_con.MySQL))
                {
                    var sql = @"Select *from points";
                    var query = c.Query<Point>(sql, commandTimeout: 30).ToList();
                    return Ok(query);
                }
            });
        }
        // GET: api/v1/points/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await Task.Run(() =>
            {
                using (var c = new MySqlConnector.MySqlConnection(_con.MySQL))
                {
                    var sql = @"Select *from points where id=" + id;
                    var query = c.Query<Point>(sql, commandTimeout: 30).ToList();
                    return Ok(query);
                }
            });
        }
        //POST: api/v1/Points
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Point point)
        {
            return await Task.Run(() =>
            {
                using (var c = new MySqlConnector.MySqlConnection(_con.MySQL))
                {
                    var sql = "INSERT INTO points(xCoordinate, yCoordinate, descriptions, dt) VALUES(@xCoordinate, @yCoordinate, @descriptions, @dt)";
                    c.Execute(sql, point, commandTimeout: 30);
                    return Ok();
                }
            });
        }
        //PUT: api/v1/Points/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Point point, int id)
        {
            return await Task.Run(() =>
            {
                using (var c = new MySqlConnector.MySqlConnection(_con.MySQL))
                {
                    var sql = "Update points set xCoordinate=@xCoordinate, yCoordinate=@yCoordinate, descriptions=@descriptions, dt=@dt where id=@id";
                    c.Execute(sql, point, commandTimeout: 30);
                    return Ok();
                }
            });
        }
        //Delete: api/v1/Points/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await Task.Run(() =>
            {
                using (var c = new MySqlConnector.MySqlConnection(_con.MySQL))
                {
                    var sql = "Delete from points where id=" + id;
                    c.Execute(sql, commandTimeout: 30);
                    return Ok();
                }
            });
        }
    }
}
