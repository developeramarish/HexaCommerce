import { ModuleWithProviders } from '@angular/core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//user pages
import { AppComponent } from './modules/app/components/app/app.component';
import { NavMenuComponent } from './modules/app/components/navmenu/navmenu.component';
import { HomeComponent } from './modules/app/components/home/home.component';
import { FetchDataComponent } from './modules/app/components/fetchdata/fetchdata.component';

//admin pages
//import { AdminAppComponent } from './modules/admin/components/adminapp/adminapp.component';
//import { AdminNavMenuComponent } from './modules/admin/components/adminnavmenu/adminnavmenu.component';
//import { DashboardComponent } from './modules/admin/components/dashboard/dashboard.component';

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'Home', component: HomeComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: 'Admin', loadChildren: './modules/admin/admin.shared.module#AdminAppModuleShared' },
    //{ path: 'Admin', component: AdminAppComponent },
    //{ path: 'Dashboard', component: DashboardComponent },
    { path: '**', redirectTo: 'Home' }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { useHash: true })
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { } 