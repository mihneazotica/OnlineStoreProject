import { NbLayoutModule, NbCardModule, NbListModule, NbOptionComponent, NbOptionModule, NbSelectModule, NbBadgeModule, NbButtonModule } from '@nebular/theme';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ProductItemComponent } from './product-item/product-item.component';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent
  ],
  imports: [
    CommonModule,
    NbLayoutModule,
    NbCardModule,
    NbListModule,
    NgxDatatableModule,
    NbOptionModule,
    NbSelectModule,
    NbBadgeModule,
    NbButtonModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
