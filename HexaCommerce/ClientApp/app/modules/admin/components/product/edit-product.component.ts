import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { ProductModel } from '../../models/product.model';
import { CategoryModel } from '../../models/category.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../../../shared/repository.service';
import { Message } from 'primeng/api';
import { PictureModel } from '../../models/picture.model';

@Component({
    selector: 'editProduct',
    templateUrl: './edit-product.component.html',
    providers: [RepositoryService]
})

export class EditProductComponent implements OnInit, OnDestroy {

    product: ProductModel;
    products: ProductModel[];
    productFrm: FormGroup;
    categories: CategoryModel[];
    id: number;
    action: string = "Add";
    private sub: any;
    msgs: Message[] = [];
    uploadedFiles: any[] = [];
    pictureId: number;
    pictureModel: PictureModel;

    constructor(private _repositoryService: RepositoryService,
        private fb: FormBuilder,
        private _route: ActivatedRoute) {
    }

    ngOnInit(): void {

        this.sub = this._route.params.subscribe(params => {
            this.id = +params['id'];
        });

        this._repositoryService.get("/admin/api/category/").subscribe(data => {
            this.categories = data;
        });

        this._repositoryService.get("/admin/api/product/").subscribe(data => {
            this.products = data;
        });

        if (this.id) {
            this.action = "Edit";

            this._repositoryService.getById(this.id, "/admin/api/product/").subscribe(data => {
                this.product = data;
                this.productFrm = this.fb.group({
                    Id: this.product.Id,
                    Name: this.product.Name,
                    ShortDescription: [this.product.ShortDescription, Validators.required],
                    FullDescription: [this.product.FullDescription],
                    ShowOnHomePage: [this.product.ShowOnHomePage],
                    Price: [this.product.Price],
                    Deleted: [this.product.Deleted],
                    Published: [this.product.Published],
                    DisplayOrder: [this.product.DisplayOrder],
                    CategoryId: [this.product.CategoryId]
                });
                this.pictureModel = data.Picture;
            }, error => {
                if (error) {
                    this.msgs = [];
                    this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in loading product...' });
                }
            });

        }
        else {
            this.productFrm = this.fb.group({
                Id: 0,
                Name: ['', Validators.required],
                ShortDescription: ['', Validators.required],
                FullDescription: '',
                ShowOnHomePage: true,
                Price: [0, Validators.required],
                Deleted: false,
                Published: true,
                DisplayOrder: 0,
                CategoryId: [],
            });
        }
    }

    onSubmit(productFrm: any) {
        if (productFrm.Id > 0) {
            this._repositoryService.put(productFrm, "/admin/api/product").subscribe(
                data => {
                    if (data.status == 200) {
                        this.msgs = [];
                        this.msgs.push({ severity: 'success', summary: 'Success', detail: 'Product Updated' });
                    }
                    else {
                        this.msgs = [];
                        this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in Updating Product' });
                    }
                }
            );
        }
        else {
            this._repositoryService.post(productFrm, "/admin/api/product").subscribe(
                data => {
                    if (data.status == 200) {
                        this.msgs = [];
                        this.msgs.push({ severity: 'success', summary: 'Success', detail: 'New Product Added' });
                    }
                    else {
                        this.msgs = [];
                        this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in Adding new Product' });
                    }
                }
            );
        }

        this.ngOnInit();
    }

    onUpload(event: any) {

        this.pictureId = event.xhr.response;
        this.msgs = [];
        this.msgs.push({ severity: 'info', summary: 'Picture Uploaded, Please Save Product', detail: '' });
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }

    private onBeforeSend(event: any) {
        var userJson = localStorage.getItem('currentCustomer');
        var token = userJson !== null ? JSON.parse(userJson).token : null;
        event.xhr.setRequestHeader("Token", token);
    }
}
