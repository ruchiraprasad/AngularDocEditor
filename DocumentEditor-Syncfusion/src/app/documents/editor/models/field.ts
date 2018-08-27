export class Field {
    id: string;
    name: string;
    displayName: string;
    content: string;
  }
  
  export class FieldCategory {
    category: string;
    fields: Field[];
  }