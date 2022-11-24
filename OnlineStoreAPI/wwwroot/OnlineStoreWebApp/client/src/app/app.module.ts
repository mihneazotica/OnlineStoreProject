import { CoreModule } from './core/core.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbCardModule, NbMenuModule, NbListModule, NbActionsModule, NbSearchComponent, NbSearchModule, NbIconComponent, NbButtonModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ShopModule } from './shop/shop.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'corporate' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbSidebarModule.forRoot(),
    NbCardModule,
    NbListModule,
    NbMenuModule.forRoot(),
    NbSearchModule,
    NbActionsModule,
    HttpClientModule,
    CoreModule,
    ShopModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
