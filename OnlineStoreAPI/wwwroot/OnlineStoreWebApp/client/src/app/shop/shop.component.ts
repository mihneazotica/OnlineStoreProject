import { ShopService } from './shop.service';
import { IProduct } from '../shared/models/product';
import { Component, OnInit } from '@angular/core';
import { IProductType } from '../shared/models/productType';
import { IBrand } from '../shared/models/brand';
import { Pipe, PipeTransform } from '@angular/core';
import { IBrandPagination } from '../shared/models/pagination';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[] = [] ;
  brands: IBrand[] = [];
  productTypes: IProductType[] = [];
  selectedItem = '2';
  brandIdSelected !: number;
  typeIdSelected !: number;


  columns = [
    { prop: 'name' },
    { name: 'Price' },
    { name: 'Description' },
    { name: 'ProductType' },
    { name: 'ProductBrand' },
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProduct();
    this.getBrands();
    this.getProductTypes();
  }

  getProduct() {
    this.shopService.getProducts(this.brandIdSelected,this.typeIdSelected).subscribe(
      {
        next: (response) => {
          this.products = response.data;
        },
        error: (error) => {
          console.log(error);
        }
      }
    );
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      {
        next: (response) => {
         this.brands = [{id: 0, name: 'All'}, ...response.data];
         console.log(this.brands);
        },
        error: (error) => {
          console.log(error);
        }
      }
    );
  }

  getProductTypes() {
    this.shopService.getTypes().subscribe(
      {
        next: (response) => {
         this.productTypes = [{id: 0, name: 'All'}, ...response.data];
        },
        error: (error) => {
          console.log(error);
        }
      }
    );
  }

  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProduct();
  }

  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProduct();
  }

}
