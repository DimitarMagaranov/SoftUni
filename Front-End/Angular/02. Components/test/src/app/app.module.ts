import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';
import { ListItemComponent } from './list-item/list-item.component';

@NgModule({
  //template specific items:
  declarations: [
    AppComponent,
    ListComponent,
    ListItemComponent
  ],
  imports: [
    BrowserModule // this. includes CommonModule
  ],
  providers: [], // osed for Dependency Injection
  bootstrap: [AppComponent] // we set in the array the components which are used in index.html
})
export class AppModule { }
