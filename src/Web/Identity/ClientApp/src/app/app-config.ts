import { AppConfig } from 'util-angular';
import { urlConfig } from './config/url-config';

/**
 * 应用配置
 */
export const appConfig: AppConfig = {
    /**
     * Api端点地址
     */
    apiEndpoint: urlConfig.apiEndpointUrl,
    /**
     * 启用多租户
     */
    tenant: {        
        isEnabled:false
    }
}