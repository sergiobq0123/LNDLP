import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumAdminComponent } from './album-admin.component';

describe('AlbumAdminComponent', () => {
  let component: AlbumAdminComponent;
  let fixture: ComponentFixture<AlbumAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlbumAdminComponent]
    });
    fixture = TestBed.createComponent(AlbumAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
