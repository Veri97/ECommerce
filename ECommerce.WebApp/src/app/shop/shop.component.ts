import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {IProduct} from "../shared/models/product";
import {ShopService} from "./shop.service";
import {IProductBrand} from "../shared/models/productBrands";
import {IProductType} from "../shared/models/productType";
import {ShopParams} from "../shared/models/shopParams";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  @ViewChild('sort') sortList: ElementRef;
  products: IProduct[];
  brands: IProductBrand[];
  types: IProductType[];
  shopParams = new ShopParams();
  totalResults: number;

  sortOptions = [
    {name: 'Alphabetical', value:'name'},
    {name: 'Price: Low to High', value:'priceAsc'},
    {name: 'Price: High to Low', value:'priceDesc'},
  ];


  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(){
    this.shopService.getProducts(this.shopParams).subscribe(response => {
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalResults = response.totalResults;
    }, error => {
      console.log(error);
    });
  }

  getBrands(){
    this.shopService.getProductBrands().subscribe(response => {
      //spread operator (...) spreads all the items/objects of an array
      //[{id: 0, name: 'All'},...response]  -> here, we spread the array of brands, and add another object with id=0, name=All to the beginning of the array
      this.brands = [{id: 0, name: 'All'},...response];
    }, error => {
      console.log(error);
    });
  }

  getTypes(){
    this.shopService.getProductTypes().subscribe(response => {
      this.types = [{id: 0, name: 'All'},...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: number){
    this.shopParams.brandId= brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.shopParams.typeId= typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string){
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any){
    if(this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(){
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset(){
    this.shopParams = new ShopParams();
    this.searchTerm.nativeElement.value = '';
    this.sortList.nativeElement.value = this.shopParams.sort;
    this.getProducts();
  }
}
