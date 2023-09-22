using Util.Platform.Identity.Domain.Models;
using Util.Platform.Identity.Dtos;

namespace Util.Platform.Identity.Applications.ObjectMapping; 

/// <summary>
/// 操作资源参数映射配置
/// </summary>
public class OperationDtoAutoMapperConfig : IAutoMapperConfig {
    /// <summary>
    /// 配置映射
    /// </summary>
    /// <param name="expression">配置映射表达式</param>
    public void Config( IMapperConfigurationExpression expression ) {
        expression.CreateMap<Resource, OperationDto>()
            .ForMember( t => t.ModuleId, t => t.MapFrom( r => r.ParentId ) )
            .ForMember( t => t.ModuleName,t => t.MapFrom( r => r.Parent.Name ) );
    }
}