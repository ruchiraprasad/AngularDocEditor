import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders, CUSTOM_ELEMENTS_SCHEMA, Type  } from '@angular/core';
import { HttpModule, JsonpModule } from '@angular/http';

import { ButtonModule, CheckBoxModule } from '@syncfusion/ej2-ng-buttons';
import { DropDownButtonModule, SplitButtonModule } from '@syncfusion/ej2-ng-splitbuttons';
import { NumericTextBoxModule, ColorPickerModule, UploaderModule, SliderModule } from '@syncfusion/ej2-ng-inputs';
import { ToolbarModule, TabModule } from '@syncfusion/ej2-ng-navigations';
import { MultiSelectModule } from '@syncfusion/ej2-ng-dropdowns';
import { DiagramAllModule, SymbolPaletteAllModule, OverviewAllModule } from '@syncfusion/ej2-ng-diagrams';
import { ComboBoxModule, DropDownListModule, DropDownListAllModule } from '@syncfusion/ej2-ng-dropdowns';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { DocumentEditorAllModule } from '@syncfusion/ej2-ng-documenteditor';
import { DialogModule } from '@syncfusion/ej2-ng-popups';

import { SharedModule } from './documents/shared/shared.module';
import { AppComponent } from './app.component';
import { DocumentsComponent } from './documents/documents.component';
import { EditorComponent } from './documents/editor/editor.component';




@NgModule({
  declarations: [
    AppComponent,
    DocumentsComponent,
    EditorComponent
  ],
  imports: [
    BrowserModule, HttpModule, JsonpModule, ButtonModule, CheckBoxModule, DropDownButtonModule, SplitButtonModule, 
    NumericTextBoxModule, ColorPickerModule, UploaderModule, SliderModule, ToolbarModule, TabModule, MultiSelectModule,
    DiagramAllModule, SymbolPaletteAllModule, OverviewAllModule, ComboBoxModule, DropDownListModule, DropDownListAllModule,
    FormsModule, ReactiveFormsModule, DocumentEditorAllModule, DialogModule, SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
