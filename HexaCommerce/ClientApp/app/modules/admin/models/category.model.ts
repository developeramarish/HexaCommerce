import { PictureModel } from './picture.model';

export class CategoryModel {
    public Id: number;
    public Name: string;
    public Description: string;
    public PictureId: number;
    public ParentCategoryId: number;
    public IncludeInNavigation: boolean;
    public Active: boolean;
    public Deleted: boolean;
    public DisplayOrder: number;
    public CreatedOn: Date;
    public Picture: PictureModel
}

