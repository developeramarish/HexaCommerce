import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './adminapp.routing'

//admin pages
import { AdminAppComponent } from './components/adminapp/adminapp.component';
import { AdminNavMenuComponent } from './components/adminnavmenu/adminnavmenu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CategoryComponent } from './components/category/category.component';


@NgModule({
    declarations: [
        //admin components
        AdminAppComponent,
        AdminNavMenuComponent,
        DashboardComponent,
        CategoryComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AdminRoutingModule
    ],
    bootstrap: [
        AdminAppComponent
    ]
})
export class AdminAppModuleShared {
}