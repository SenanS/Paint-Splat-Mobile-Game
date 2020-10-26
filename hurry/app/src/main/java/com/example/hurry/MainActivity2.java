package com.example.hurry;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

public class MainActivity2 extends AppCompatActivity {



    ListView listView;
    Button button;

    List<String> roomList;
    List<String> playerList;

    String playerName = "";
    String roomName = "";

    FirebaseDatabase database;
    DatabaseReference roomRef;
    DatabaseReference roomsRef;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        database = FirebaseDatabase.getInstance();
        SharedPreferences preferences = getSharedPreferences("PREFS", 0);
        playerName = preferences.getString("playerName", "");
        roomName = playerName;

        listView = findViewById(R.id.listview);
        button = findViewById(R.id.button2);

        roomList = new ArrayList<>();
        playerList = new ArrayList<>();


        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
               /* button.setText("Creating Room");
                button.setEnabled(false);
                roomName = "Testing";
                roomRef = database.getReference("rooms/" + roomName + "/player1");
                addRoomEventListener();
                roomRef.setValue(playerName);*/
                Intent intent =  new Intent(getApplicationContext(),MainActivity4.class);
                intent.putExtra("playerName", playerName);
                startActivity(intent);
                finish();
            }
        });


        final ArrayList<String> list = new ArrayList<>();
        String test;

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                roomName = roomList.get(position);
                roomsRef = database.getReference("rooms/"+roomName);

                roomsRef.addListenerForSingleValueEvent(new ValueEventListener() {
                    @Override
                    public void onDataChange(@NonNull DataSnapshot snapshot) {
                        list.clear();
                        for(DataSnapshot Snapshot : snapshot.getChildren()){
                            list.add(snapshot.getValue().toString());
                        }

                        if(list.size()==2){
                            roomRef = database.getReference("rooms/" + roomName + "/player2");
                            addRoomEventListener();
                            roomRef.setValue(playerName);
                        }
                        if(list.size()==3){
                            roomRef = database.getReference("rooms/" + roomName + "/player3");
                            addRoomEventListener();
                            roomRef.setValue(playerName);
                        }

                        if(list.size()==4){
                            roomRef = database.getReference("rooms/" + roomName + "/player4");
                            addRoomEventListener();
                            roomRef.setValue(playerName);
                        }
                    }

                    @Override
                    public void onCancelled(@NonNull DatabaseError error) {

                    }
                });

            }
        });
        //show if new room is available
        addRoomsEventListener();
    }

    private void addRoomEventListener(){
        roomRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                //join the room
                button.setText("Create Room");
                button.setEnabled(true);
                Intent intent = new Intent(getApplicationContext(), MainActivity3.class);
                intent.putExtra("roomName",roomName);
                startActivity(intent);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                //error
                button.setText("Create Room");
                button.setEnabled(true);
                Toast.makeText(MainActivity2.this, "ERROR", Toast.LENGTH_SHORT).show();

            }
        });



    }

    private void addRoomsEventListener(){

       roomRef = database.getReference("rooms");
       roomRef.addValueEventListener(new ValueEventListener() {
           @Override
           public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
               //show list of rooms

               roomList.clear();
               Iterable<DataSnapshot> rooms = dataSnapshot.getChildren();
               for(DataSnapshot snapshot:rooms){
                   roomsRef = database.getReference("rooms/"+roomName);

                   roomsRef.addListenerForSingleValueEvent(new ValueEventListener() {
                       @Override
                       public void onDataChange(@NonNull DataSnapshot snapshot) {
                           playerList.clear();
                           for (DataSnapshot Snapshot : snapshot.getChildren()) {
                               playerList.add(snapshot.getValue().toString());
                           }

                           if (playerList.size() != 5) {
                               roomList.add(snapshot.getKey());
                               ArrayAdapter<String> adapter = new ArrayAdapter<>(MainActivity2.this,
                                       android.R.layout.simple_list_item_1, roomList);
                               listView.setAdapter(adapter);
                           }
                       }


                       @Override
                       public void onCancelled(@NonNull DatabaseError error) {

                       }
               });
           }

           @Override
           public void onCancelled(@NonNull DatabaseError error) {
                //error - nothing
           }
       });


    }





}