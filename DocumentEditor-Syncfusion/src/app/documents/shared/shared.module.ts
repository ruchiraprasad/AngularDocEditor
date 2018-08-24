import { NgModule } from '@angular/core';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { ListViewModule } from '@syncfusion/ej2-ng-lists';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';
import { TreeViewModule, TabModule } from '@syncfusion/ej2-ng-navigations';
import { RichTextEditorAllModule } from '@syncfusion/ej2-ng-richtexteditor';

@NgModule({
    imports: [
        ButtonModule,
        ListViewModule,
        DropDownListModule,
        TreeViewModule,
        TabModule,
        RichTextEditorAllModule
    ],
     
    exports: [
        ButtonModule,
        TreeViewModule,
        ListViewModule,
        DropDownListModule,
        TabModule,
        RichTextEditorAllModule
    ]
})
export class SharedModule { }