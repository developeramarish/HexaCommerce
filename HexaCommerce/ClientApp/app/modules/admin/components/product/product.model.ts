import { PictureModel } from '../../../../shared/picture.model';

export class ProductModel {
    public Id: number;
    public Name: string;
    public ShortDescription: string;
    public FullDescription: string;
    public AdminComment: string;
    public ShowOnHomePage: boolean;
    public AllowCustomerReviews: boolean;
    public Sku: string;
    public ManufacturerPartNumber: string;
    public IsShipEnabled: boolean;
    public IsFreeShipping: boolean;
    public IsTaxExempt: boolean;
    public StockQuantity: number;
    public DisplayStockAvailability: boolean;
    public DisplayStockQuantity: boolean;
    public MinStockQuantity: number;
    public DisableBuyButton: boolean;
    public Price: number;
    public OldPrice: number;
    public ProductCost: number;
    public MarkAsNew: number;
    public Weight: number;
    public Length: number;
    public Width: number;
    public Height: number;
    public DisplayOrder: number;
    public Published: boolean;
    public Deleted: boolean;
    public PictureThumbnailUrl: string

    public Pictures: PictureModel[]
}

