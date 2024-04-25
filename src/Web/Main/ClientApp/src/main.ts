import { NzSafeAny } from 'ng-zorro-antd/core/types';
import { loadManifest } from '@angular-architects/module-federation';

/**
 * window
 */
const win = window as NzSafeAny;

/**
 * 微前端配置Url
 */
export function getManifestUrl() {
    const result = '/assets/mf.manifest.json';
    if (!win.bootstrapConfig)
        return result;
    if (!win.bootstrapConfig.manifestUrl)
        return result;
    if (win.bootstrapConfig.manifestUrl === '${ManifestUrl}')
        return result;
    return win.bootstrapConfig.manifestUrl;
}

/**
 * 加载微前端配置并启动
 */
loadManifest(getManifestUrl())
    .catch(err => console.error(err))
    .then(_ => import('./bootstrap'))
    .catch(err => console.error(err));