import { NgModule } from '@angular/core';
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing'
import { BsModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';

//user pages
import { AppComponent } from './modules/app/components/app/app.component';
import { NavMenuComponent } from './modules/app/components/navmenu/navmenu.component';
import { HomeComponent } from './modules/app/components/home/home.component';
import { FetchDataComponent } from './modules/app/components/fetchdata/fetchdata.component';
import { LoginComponent } from '../app/modules/app/components/login/login.component'
import { LogoutComponent } from '../app/modules/app/components/login/logout.component'

import { AdminAppModuleShared } from './modules/admin/admin.shared.module';


@NgModule({
    declarations: [
        //user components
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,
        LoginComponent,
        LogoutComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        BsModalModule,
        AdminAppModuleShared
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}