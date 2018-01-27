import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AdminAppModuleShared } from './modules/admin/admin.shared.module';
import { AppComponent } from './modules/app/components/app/app.component';
import { AdminAppComponent } from './modules/admin/components/adminapp/adminapp.component'

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        ServerModule,
        AppModuleShared,
        AdminAppModuleShared
    ]
})
export class AppModule {
}
