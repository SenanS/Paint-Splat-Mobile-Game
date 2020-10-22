package com.example.hurry;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

public class MainActivity4 extends AppCompatActivity {
    EditText roomNameText;
    Button createRoomButton;

    String roomName = "";
    String playerName = "";

    FirebaseDatabase database;
    DatabaseReference roomRef;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main4);

        roomNameText = findViewById(R.id.roomNameText);
        createRoomButton = findViewById(R.id.createRoomButton);

        database = FirebaseDatabase.getInstance();
        //SharedPreferences preferences = getSharedPreferences("PREFS", 0);
        //playerName = preferences.getString("playerName", "");
        playerName = getIntent().getStringExtra("playerName");

        createRoomButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                createRoomButton.setText("Create Room");
                createRoomButton.setEnabled(false);
                roomName = roomNameText.getText().toString();
                roomRef = database.getReference("rooms/" + roomName + "/player1");
                addRoomEventListener();
                roomRef.setValue(playerName);


            }
        });

    }

    private void addRoomEventListener() {
        roomRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                //join the room
                createRoomButton.setText("Create Room");
                createRoomButton.setEnabled(true);
                Intent intent = new Intent(getApplicationContext(), MainActivity3.class);
                intent.putExtra("roomName", roomName);
                startActivity(intent);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                //error
                createRoomButton.setText("Create Room");
                createRoomButton.setEnabled(true);
                Toast.makeText(MainActivity4.this, "ERROR", Toast.LENGTH_SHORT).show();

            }
        });
    }
}