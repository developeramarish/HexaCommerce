import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { ProductModel } from './product.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../../../shared/repository.service';
import { Message } from 'primeng/api';
import { PictureModel } from '../../../../shared/picture.model';

@Component({
    selector: 'editProduct',
    templateUrl: './edit-product.component.html',
    providers: [RepositoryService]
})

export class EditProductComponent implements OnInit, OnDestroy {

    product: ProductModel;
    products: ProductModel[];
    productFrm: FormGroup;
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

        //this.sub = this._route.params.subscribe(params => {
        //    this.id = +params['id'];
        //});

        //this._repositoryService.get("/admin/api/product/").subscribe(data => {
        //    this.products = data;
        //});

        //if (this.id) {
        //    this.action = "Edit";

        //    this._repositoryService.getById(this.id, "/admin/api/category/").subscribe(data => {
        //        this.product = data;
        //        this.productFrm = this.fb.group({
        //            Id: this.product.Id,
        //            Name: this.product.Name,
        //            Description: [this.product.ShortDescription, Validators.required],
        //            ParentCategoryId: [this.product.ParentCategoryId],
        //            IncludeInNavigation: [this.category.IncludeInNavigation],
        //            Active: [this.category.Active],
        //            Deleted: [this.category.Deleted],
        //            DisplayOrder: [this.category.DisplayOrder],
        //            PictureId: [this.category.PictureId]
        //        });
        //        this.pictureModel = data.Picture;
        //    }, error => {
        //        if (error) {
        //            this.msgs = [];
        //            this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in loading category...' });
        //        }
        //    });

        //}
        //else {
        //    this.categoryFrm = this.fb.group({
        //        Id: 0,
        //        Name: ['', Validators.required],
        //        Description: ['', Validators.required],
        //        ParentCategoryId: [],
        //        IncludeInNavigation: [true],
        //        Active: [true],
        //        Deleted: [false],
        //        DisplayOrder: [0],
        //        SelectedParentCategory: [],
        //        PictureId: []
        //    });
        //}
    }

    onSubmit(categoryFrm: any) {
        categoryFrm.PictureId = this.pictureId;
        if (categoryFrm.Id > 0) {
            this._repositoryService.put(categoryFrm, "/admin/api/category").subscribe(
                data => {
                    if (data.status == 200) {
                        this.msgs = [];
                        this.msgs.push({ severity: 'success', summary: 'Success', detail: 'Category Updated' });
                    }
                    else {
                        this.msgs = [];
                        this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in Updating Category' });
                    }
                }
            );
        }
        else {
            this._repositoryService.post(categoryFrm, "/admin/api/category").subscribe(
                data => {
                    if (data.status == 200) {
                        this.msgs = [];
                        this.msgs.push({ severity: 'success', summary: 'Success', detail: 'New Category Added' });
                    }
                    else {
                        this.msgs = [];
                        this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in Adding new Category' });
                    }
                }
            );
        }

        this.ngOnInit();
    }

    onUpload(event: any) {

        this.pictureId = event.xhr.response;
        this.msgs = [];
        this.msgs.push({ severity: 'info', summary: 'Picture Uploaded, Please Save Category', detail: '' });
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
