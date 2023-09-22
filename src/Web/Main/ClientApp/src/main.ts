import { loadManifest } from '@angular-architects/module-federation';
import { urlConfig } from './app/config/url-config';

/**
 * ����΢ǰ�����ò�����
 */
loadManifest(urlConfig.microfrontendsManifestUrl)
  .catch(err => console.error(err))
  .then(_ => import('./bootstrap'))
  .catch(err => console.error(err));
