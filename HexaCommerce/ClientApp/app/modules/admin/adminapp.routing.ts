import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

//admin pages
import { AdminAppComponent } from './components/adminapp/adminapp.component';
import { AdminNavMenuComponent } from './components/admin-navmenu/admin-navmenu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CategoryComponent } from './components/category/category.component';
import { EditCategoryComponent } from './components/category/edit-category.component';
import { ProductComponent } from './components/product/product.component';
import { EditProductComponent } from './components/product/edit-product.component';

const routes: Routes = [
    {
        path: '',
        component: AdminAppComponent,
        children: [
            { path: 'Dashboard', component: DashboardComponent },
            { path: 'Category', component: CategoryComponent },
            { path: 'AddCategory', component: EditCategoryComponent },
            { path: 'EditCategory/:id', component: EditCategoryComponent },
            { path: 'Product', component: ProductComponent },
            { path: 'AddProduct', component: EditProductComponent},
            { path: 'EditProduct/:id', component: EditProductComponent},
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