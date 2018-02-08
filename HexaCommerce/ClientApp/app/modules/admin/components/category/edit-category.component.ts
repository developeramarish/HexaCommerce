import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { CategoryModel } from './category.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../../../shared/repository.service';
import { Message } from 'primeng/api';

@Component({
    selector: 'editCategory',
    templateUrl: './edit-category.component.html',
    providers: [RepositoryService]
})

export class EditCategoryComponent implements OnInit, OnDestroy {

    category: CategoryModel;
    categories: CategoryModel[];
    categoryFrm: FormGroup;
    id: number;
    action: string = "Add";
    private sub: any;
    msgs: Message[] = [];

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

        if (this.id) {
            this.action = "Edit";

            this._repositoryService.getById(this.id, "/admin/api/category/").subscribe(data => {
                this.category = data
                this.categoryFrm = this.fb.group({
                    Id: this.category.Id,
                    Name: this.category.Name,
                    Description: [this.category.Description, Validators.required],
                    ParentCategoryId: [this.category.ParentCategoryId],
                    IncludeInNavigation: [this.category.IncludeInNavigation],
                    Active: [this.category.Active],
                    Deleted: [this.category.Deleted],
                    DisplayOrder: [this.category.DisplayOrder],
                    SelectedParentCategory: [this.categories.filter(a => a.Id == this.category.ParentCategoryId)[0]]
                });
            }, error => {
                if (error) {
                    alert("Error")
                }
            });

        }
        else {
            this.categoryFrm = this.fb.group({
                Id: 0,
                Name: ['', Validators.required],
                Description: ['', Validators.required],
                ParentCategoryId: [],
                IncludeInNavigation: [true],
                Active: [true],
                Deleted: [false],
                DisplayOrder: [0],
                SelectedParentCategory: []
            });
        }
    }

    onSubmit(categoryFrm: any) {
        categoryFrm.ParentCategoryId = categoryFrm.SelectedParentCategory.Id;
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


    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }
}
