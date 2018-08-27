import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { TemplateListItem } from '../models/templateListItem';
import { FieldCategory } from '../models/field';

@Injectable({
  providedIn: 'root'
})

export class DocumentEditorService {
  constructor(private http: HttpClient) {}

  getTemplateList(): Observable<TemplateListItem[]> {
    return this.http.get<TemplateListItem[]>('http://localhost:52061/api/values/GetTemplateList');
  }

  getTemplate(selectedItemId: string): Observable<string> {
    return this.http.get<string>('http://localhost:52061/api/values/GetTemplate/' + selectedItemId);
  }

  getFields(): Observable<FieldCategory[]> {
    return this.http.get<FieldCategory[]>('http://localhost:52061/api/fields');
  }
}
