﻿namespace SchedulerApp.Modules.Database;

using Newtonsoft.Json;
using Npgsql;
using SchedulerApp.Data.Scheduler;

public static class Postgres
{
    public static string ConnectionString = string.Empty;

    public static async Task<bool> AddUser()
    {
        return true;
    }
    public static async Task<bool> UpdateUser()
    {
        return true;
    }

    public static async Task<bool> LogProblem(Problem problem)
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        await conn.OpenAsync();
        using var cmd = new NpgsqlCommand("INSERT INTO Problems (problemdata) VALUES (CAST(@problemdata AS JSON))", conn);
        cmd.Parameters.Add(new NpgsqlParameter("problemdata", JsonConvert.SerializeObject(problem)));
        var result = await cmd.ExecuteNonQueryAsync();
        await conn.CloseAsync();
        return result != -1;
    }

}

