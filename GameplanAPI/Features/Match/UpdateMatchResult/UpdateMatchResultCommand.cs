﻿using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatchResult
{
    public sealed record UpdateMatchResultCommand(
        Guid Id,
        int HomeScore,
        int AwayScore,
        MatchStatus MatchStatus)
        : ICommand;
}
