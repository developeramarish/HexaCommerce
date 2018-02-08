import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './adminapp.routing'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTableModule } from 'primeng/datatable'
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { GrowlModule } from 'primeng/growl';
import { DropdownModule } from 'primeng/dropdown';
import { EditorModule } from 'primeng/editor';

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
        AdminRoutingModule,
        DataTableModule,
        ConfirmDialogModule,
        GrowlModule,
        DropdownModule,
        EditorModule
    ],
    bootstrap: [
        AdminAppComponent
    ],
    providers: []
})
export class AdminAppModuleShared {
}