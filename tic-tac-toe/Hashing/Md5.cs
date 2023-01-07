﻿using System.Security.Cryptography;
using System.Text;

namespace tic_tac_toe.Hashing;

public static class Md5
{
    public static string HashPassword(string password)
    {
        var md5 = MD5.Create();
        var b = Encoding.ASCII.GetBytes(password);
        var hash = md5.ComputeHash(b);

        var sb = new StringBuilder();
        foreach (var a in hash)
        {
            sb.Append(a.ToString("X2"));
        }

        return sb.ToString();
    }
}