using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Championships.GetChampionshipById;

public sealed record GetChampionshipByIdQuery(
    Guid Id) : IQuery<ChampionshipResponse>;