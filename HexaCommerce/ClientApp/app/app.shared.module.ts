import { NgModule } from '@angular/core';
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing'
import { BsModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { Ng2PaginationModule } from 'ng2-pagination'; //importing ng2-pagination

//user pages
import { AppComponent } from './modules/app/components/app/app.component';
import { NavMenuComponent } from './modules/app/components/navmenu/navmenu.component';
import { HomeComponent } from './modules/app/components/home/home.component';
import { LoginComponent } from '../app/modules/app/components/login/login.component';
import { LogoutComponent } from '../app/modules/app/components/login/logout.component';
import { FooterComponent } from '../app/modules/app/components/footer/footer.component';

import { AdminAppModuleShared } from './modules/admin/admin.shared.module';


@NgModule({
    declarations: [
        //user components
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        LoginComponent,
        LogoutComponent,
        FooterComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        BsModalModule,
        AdminAppModuleShared,
        Ng2PaginationModule
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}