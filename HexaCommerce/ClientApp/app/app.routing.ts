import { ModuleWithProviders } from '@angular/core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//user pages
import { AppComponent } from './modules/app/components/app/app.component';
import { NavMenuComponent } from './modules/app/components/navmenu/navmenu.component';
import { HomeComponent } from './modules/app/components/home/home.component';
import { AuthGuard } from '../app/guards/auth.guard'
import { AdminAuthGuard } from '../app/guards/auth.adminguard'
import { LoginComponent } from '../app/modules/app/components/login/login.component'
import { LogoutComponent } from '../app/modules/app/components/login/logout.component'

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'Home', component: HomeComponent },
    { path: 'Login', component: LoginComponent },
    { path: 'Logout', component: LogoutComponent },
    { path: 'Admin', loadChildren: './modules/admin/admin.shared.module#AdminAppModuleShared', canActivate: [AuthGuard, AdminAuthGuard] },
    { path: '**', redirectTo: 'Home' }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, { useHash: false })
    ],
    exports: [RouterModule],
    providers: [AuthGuard, AdminAuthGuard]
})
export class AppRoutingModule { }