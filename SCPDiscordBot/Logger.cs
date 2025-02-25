﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace SCPDiscord
{
  internal enum LogID
  {
    GENERAL,
    CONFIG,
    NETWORK,
    COMMAND,
    DISCORD
  };

  internal static class Logger
  {
    private static readonly Dictionary<LogID, EventId> eventIDs = new()
    {
      { LogID.GENERAL, new EventId(500, "General") },
      { LogID.CONFIG,  new EventId(501, "Config")  },
      { LogID.NETWORK, new EventId(502, "Network") },
      { LogID.COMMAND, new EventId(503, "Command") },
      { LogID.DISCORD, new EventId(504, "Discord") },
    };

    internal static void Debug(string message, LogID logID)
    {
      try
      {
        DiscordAPI.client.Logger.Log(LogLevel.Debug, eventIDs[logID], message);
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("[DEBUG] " + message);
      }
    }

    internal static void Log(string message, LogID logID = LogID.GENERAL)
    {
      try
      {
        DiscordAPI.client.Logger.Log(LogLevel.Information, eventIDs[logID], message);
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("[INFO] " + message);
      }
    }

    internal static void Warn(string message, LogID logID = LogID.GENERAL)
    {
      try
      {
        DiscordAPI.client.Logger.Log(LogLevel.Warning, eventIDs[logID], message);
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("[WARNING] " + message);
      }
    }

    internal static void Error(string message, LogID logID = LogID.GENERAL)
    {
      try
      {
        DiscordAPI.client.Logger.Log(LogLevel.Error, eventIDs[logID], message);
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("[ERROR] " + message);
      }
    }

    internal static void Fatal(string message, LogID logID = LogID.GENERAL)
    {
      try
      {
        DiscordAPI.client.Logger.Log(LogLevel.Critical, eventIDs[logID], message);
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("[CRITICAL] " + message);
      }
    }
  }
}