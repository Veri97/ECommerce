import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavBarComponent} from "./nav-bar/nav-bar.component";
import {RouterModule} from "@angular/router";
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import {ToastrModule} from "ngx-toastr";



@NgModule({
  declarations: [NavBarComponent, TestErrorComponent, NotFoundComponent, ServerErrorComponent],
  imports: [
    CommonModule,
    RouterModule,
    ToastrModule.forRoot({
       positionClass: 'toast-bottom-right',
       closeButton: true,
       preventDuplicates: true,
       timeOut: 3000,
       iconClasses: {
        error: 'toast-error',
        info: 'toast-info',
        success: 'toast-success',
        warning: 'toast-warning'
      }
    })
  ],
  exports: [NavBarComponent]
})
export class CoreModule { }
