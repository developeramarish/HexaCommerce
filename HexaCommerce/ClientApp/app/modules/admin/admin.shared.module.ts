import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './adminapp.routing'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//admin pages
import { AdminAppComponent } from './components/adminapp/adminapp.component';
import { AdminNavMenuComponent } from './components/admin-navmenu/admin-navmenu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CategoryComponent } from './components/category/category.component';
import { EditCategoryComponent } from './components/category/edit-category.component';


@NgModule({
    declarations: [
        //admin components
        AdminAppComponent,
        AdminNavMenuComponent,
        DashboardComponent,
        CategoryComponent,
        EditCategoryComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,    //added here too
        ReactiveFormsModule, //added here too
        AdminRoutingModule
    ],
    bootstrap: [
        AdminAppComponent
    ]
})
export class AdminAppModuleShared {
}