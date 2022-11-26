import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { myProvider, TestComponent } from './test/test.component';



@NgModule({
  declarations: [
    TestComponent
  ],
  providers: [
    myProvider
  ],
  imports: [
    CommonModule
  ]
})
export class MyModuleModule { }
