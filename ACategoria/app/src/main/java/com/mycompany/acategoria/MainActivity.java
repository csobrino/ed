package com.mycompany.acategoria;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
/*
        DbPruebaHelper.init(this);
        DbPruebaHelper.getinstance().insertCategoria("categoria 1");
        DbPruebaHelper.getinstance().insertCategoria("categoria 2");
        DbPruebaHelper.getinstance().insertCategoria("categoria 3");*/

        List<Categoria> categorias = DbPruebaHelper.getinstance().getCategorias();

        ListView listView = (ListView) findViewById(R.id.listView);
        ArrayAdapter <Categoria> arrayAdapter = new ArrayAdapter<Categoria>(this, android.R.layout.simple_list_item_1, categorias);

        listView.setAdapter(arrayAdapter);
    }
}
