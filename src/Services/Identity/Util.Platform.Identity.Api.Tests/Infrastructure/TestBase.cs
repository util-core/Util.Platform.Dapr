namespace Util.Platform.Identity.Api.Tests.Infrastructure;

/// <summary>
/// 测试基类
/// </summary>
public abstract class TestBase {
    /// <summary>
    /// 测试初始化
    /// </summary>
    protected TestBase( IHttpClient client ) {
        Client = client;
    }

    /// <summary>
    /// Http客户端
    /// </summary>
    protected IHttpClient Client { get; }

    /// <summary>
    /// Http Get操作
    /// </summary>
    /// <typeparam name="TResult">返回结果类型</typeparam>
    /// <param name="url">服务地址</param>
    /// <param name="data">参数</param>
    protected async Task<ServiceResult<TResult>> GetAsync<TResult>( string url, object data = null ) {
        return await Client.Get<ServiceResult<TResult>>( url, data ).GetResultAsync();
    }

    /// <summary>
    /// Http Post操作
    /// </summary>
    /// <param name="url">服务地址</param>
    /// <param name="data">参数</param>
    protected async Task<ServiceResult<object>> PostAsync( string url, object data ) {
        return await PostAsync<object>( url, data );
    }

    /// <summary>
    /// Http Post操作
    /// </summary>
    /// <typeparam name="TResult">返回结果类型</typeparam>
    /// <param name="url">服务地址</param>
    /// <param name="data">参数</param>
    protected async Task<ServiceResult<TResult>> PostAsync<TResult>( string url, object data ) {
        return await Client.Post<ServiceResult<TResult>>( url, data ).GetResultAsync();
    }

    /// <summary>
    /// Http Put操作
    /// </summary>
    /// <param name="url">服务地址</param>
    /// <param name="data">参数</param>
    protected async Task<ServiceResult<object>> PutAsync( string url, object data ) {
        return await PutAsync<object>( url, data );
    }

    /// <summary>
    /// Http Put操作
    /// </summary>
    /// <typeparam name="TResult">返回结果类型</typeparam>
    /// <param name="url">服务地址</param>
    /// <param name="data">参数</param>
    protected async Task<ServiceResult<TResult>> PutAsync<TResult>( string url, object data ) {
        return await Client.Put<ServiceResult<TResult>>( url, data ).GetResultAsync();
    }

    /// <summary>
    /// Http Delete操作
    /// </summary>
    /// <param name="url">服务地址</param>
    protected async Task<ServiceResult<object>> DeleteAsync( string url ) {
        return await DeleteAsync<object>( url );
    }

    /// <summary>
    /// Http Delete操作
    /// </summary>
    /// <typeparam name="TResult">返回结果类型</typeparam>
    /// <param name="url">服务地址</param>
    protected async Task<ServiceResult<TResult>> DeleteAsync<TResult>( string url ) {
        return await Client.Delete<ServiceResult<TResult>>( url ).GetResultAsync();
    }
}