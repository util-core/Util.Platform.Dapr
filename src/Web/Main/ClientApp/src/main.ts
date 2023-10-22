import { loadManifest } from '@angular-architects/module-federation';
import { bootstrapConfig } from './app/config/bootstrap-config';

/**
 * ����΢ǰ�����ò�����
 */
loadManifest(bootstrapConfig.manifestUrl)
    .catch(err => console.error(err))
    .then(_ => import('./bootstrap'))
    .catch(err => console.error(err));
