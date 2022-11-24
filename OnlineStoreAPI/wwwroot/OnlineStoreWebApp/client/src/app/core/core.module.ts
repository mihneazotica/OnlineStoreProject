import { NbMenuModule, NbSidebarModule, NbSearchModule, NbButtonModule, NbActionsModule, NbContextMenuModule } from '@nebular/theme';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NavBarUpComponent } from './nav-bar-up/nav-bar-up.component';



@NgModule({
  declarations: [NavBarComponent, NavBarUpComponent],
  imports: [
    CommonModule,
    NbMenuModule.forRoot(),
    NbSearchModule,
    NbButtonModule,
    NbActionsModule,
    NbContextMenuModule
  ],
  exports: [NavBarComponent, NavBarUpComponent]
})
export class CoreModule { }
