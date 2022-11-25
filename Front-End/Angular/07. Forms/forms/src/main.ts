import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { createMyValueProvider } from './app/providers';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

const myValueProvider = createMyValueProvider((window as any).test);

platformBrowserDynamic([myValueProvider]).bootstrapModule(AppModule)
  .catch(err => console.error(err));
