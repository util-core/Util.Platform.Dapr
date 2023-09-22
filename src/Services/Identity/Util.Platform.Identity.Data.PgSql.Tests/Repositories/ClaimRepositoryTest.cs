namespace Util.Platform.Identity.Data.PgSql.Tests.Repositories;

/// <summary>
/// 声明仓储测试
/// </summary>
public class ClaimRepositoryTest {
    /// <summary>
    /// 工作单元
    /// </summary>
    private readonly IIdentityUnitOfWork _unitOfWork;
    /// <summary>
    /// 仓储
    /// </summary>
    private readonly IClaimRepository _repository;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public ClaimRepositoryTest( IIdentityUnitOfWork unitOfWork, IClaimRepository repository ) {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    /// <summary>
    /// 测试添加实体
    /// </summary>
    [Fact]
    public async Task TestAddAsync() {
        //添加实体
        var entity = ClaimFakeService.GetClaim();
        entity.Init();
        await _repository.AddAsync( entity );
        await _unitOfWork.CommitAsync();
        _unitOfWork.ClearCache();

        //验证
        Assert.True( await _repository.ExistsAsync( t => t.Id == entity.Id ) );
    }
}