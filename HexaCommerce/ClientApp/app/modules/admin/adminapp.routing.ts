import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

//admin pages
import { AdminAppComponent } from './components/adminapp/adminapp.component';
import { AdminNavMenuComponent } from './components/adminnavmenu/adminnavmenu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CategoryComponent } from './components/category/category.component';

const routes: Routes = [
    {
        path: '',
        component: AdminAppComponent,
        children: [
            { path: 'Dashboard', component: DashboardComponent },
            { path: 'Category', component: CategoryComponent },
        ]
    },
    {
        path: '**',
        redirectTo: ''
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }