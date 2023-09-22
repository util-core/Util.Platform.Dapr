import { OAuthModuleConfig } from 'angular-oauth2-oidc';
import { urlConfig } from '../../config/url-config';

/**
 * ��Ȩģ������
 */
export const authModuleConfig: OAuthModuleConfig = {
    resourceServer: {
        allowedUrls: [urlConfig.apiEndpointUrl],
        sendAccessToken: true
    }
};
