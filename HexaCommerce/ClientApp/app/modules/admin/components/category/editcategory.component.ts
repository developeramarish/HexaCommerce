import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { CategoryModel } from './category.model';
import { CategoryService } from './category.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';


@Component({
    selector: 'editCategory',
    templateUrl: './editcategory.component.html',
    providers: [CategoryService]
})
export class EditCategoryComponent implements OnInit, OnDestroy {

    Category: CategoryModel;
    categoryFrm: FormGroup;
    id: number;
    private sub: any;

    constructor(private _categoryService: CategoryService, private fb: FormBuilder, private _route: ActivatedRoute) { }

    ngOnInit(): void {

        this.sub = this._route.params.subscribe(params => {
            this.id = +params['id'];
        });

        this._categoryService.GetCategoryById(this.id).subscribe(data => {
            this.Category = data
            this.categoryFrm = this.fb.group({
                Name: this.Category.Name,
                Description: [this.Category.Description, Validators.required],
                ParentCategoryId: [this.Category.ParentCategoryId],
                IncludeInNavigation: [this.Category.IncludeInNavigation],
                Active: [this.Category.Active],
                Deleted: [this.Category.Deleted],
                DisplayOrder: [this.Category.DisplayOrder]
            });
        }, error => {
            if (error) {
                alert("Error")
            }
        });

        
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }
}
