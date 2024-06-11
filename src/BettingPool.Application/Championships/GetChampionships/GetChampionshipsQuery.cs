using BettingPool.SharedKernel.Application;

namespace BettingPool.Application.Championships.GetChampionships;

public sealed record GetChampionshipsQuery(
    int PageIndex,
    int PageSize) : IQuery<List<GetChampionshipsResponse>>;