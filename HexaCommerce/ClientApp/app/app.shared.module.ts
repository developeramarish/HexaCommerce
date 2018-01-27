import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing'

//user pages
import { AppComponent } from './modules/app/components/app/app.component';
import { NavMenuComponent } from './modules/app/components/navmenu/navmenu.component';
import { HomeComponent } from './modules/app/components/home/home.component';
import { FetchDataComponent } from './modules/app/components/fetchdata/fetchdata.component';

////admin pages
//import { AdminAppComponent } from './modules/admin/components/adminapp/adminapp.component';
//import { AdminNavMenuComponent } from './modules/admin/components/adminnavmenu/adminnavmenu.component';
//import { DashboardComponent } from './modules/admin/components/dashboard/dashboard.component';
import { AdminAppModuleShared } from './modules/admin/admin.shared.module';


@NgModule({
    declarations: [
        //user components
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,

        //admin components
        //AdminAppComponent,
        //AdminNavMenuComponent,
        //DashboardComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AppRoutingModule,
        AdminAppModuleShared
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}