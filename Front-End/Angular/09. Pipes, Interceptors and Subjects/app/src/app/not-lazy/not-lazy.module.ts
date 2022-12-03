import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotLazyComponent } from './not-lazy/not-lazy.component';



@NgModule({
  declarations: [
    NotLazyComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NotLazyComponent
  ]
})
export class NotLazyModule { }
