package com.works.forme;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.provider.Settings;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import com.facebook.AccessToken;
import com.facebook.CallbackManager;
import com.facebook.FacebookCallback;
import com.facebook.FacebookException;
import com.facebook.FacebookSdk;
import com.facebook.GraphRequest;
import com.facebook.GraphResponse;
import com.facebook.login.LoginManager;
import com.facebook.login.LoginResult;
import com.facebook.login.widget.LoginButton;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.AdView;
import com.google.android.gms.ads.MobileAds;
import org.json.JSONObject;

/**
 * Created by normen on 23.05.17.
 */

public class StartActivity extends Activity {

    private Button startGame;
    private CallbackManager callbackManager;
    private LoginButton loginButton;
    private AdView mAdView;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        FacebookSdk.setApplicationId("1679212205713329");
        FacebookSdk.sdkInitialize(getApplicationContext());
        callbackManager = CallbackManager.Factory.create();
        setContentView(R.layout.activity_main);

        //### ADMOB Setup ###
        String android_id = Settings.Secure.getString(getApplicationContext().getContentResolver(),
                Settings.Secure.ANDROID_ID);
        Log.d("ID",android_id);

        MobileAds.initialize(getApplicationContext(),"ca-app-pub-9202887805780186~1585633352");
        mAdView = (AdView) findViewById(R.id.adViewBanner);
        AdRequest adRequest = new AdRequest.Builder().addTestDevice("00B74723240B0E3655D79216720F1ABC").build();
        mAdView.loadAd(adRequest);



        // #### Facebook Setup ###

        AccessToken token;
        token = AccessToken.getCurrentAccessToken();

        //check if the user is already logged in
        if (token != null) {
            startActivity(new Intent(StartActivity.this,UnityPlayerActivity.class));
        }
        loginButton =(LoginButton) findViewById(R.id.login_button);
        loginButton.registerCallback(callbackManager, new FacebookCallback<LoginResult>() {
            @Override
            public void onSuccess(LoginResult loginResult) {
                Log.d("onSuccess", loginResult.getAccessToken().getUserId());
                loadData(loginResult);
                startActivity(new Intent(StartActivity.this,UnityPlayerActivity.class));

            }
            @Override
            public void onCancel() {
                Log.d("onCancel","AAA");
            }

            @Override
            public void onError(FacebookException e) {
                Log.d("onError",e.toString());
            }
        });







        // ### UI initialization ###
        startGame = (Button) findViewById(R.id.start_game);
        startGame.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(StartActivity.this,UnityPlayerActivity.class));
            }
        });
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        callbackManager.onActivityResult(requestCode, resultCode, data);
    }
    private void loadData(LoginResult loginResult){
        GraphRequest request = GraphRequest.newMeRequest(
                loginResult.getAccessToken(),
                new GraphRequest.GraphJSONObjectCallback() {
                    @Override
                    public void onCompleted(
                            JSONObject object,
                            GraphResponse response) {
                        // Application code
                        JSONParser jsonParser = new JSONParser(getApplicationContext());
                        jsonParser.parseJSON(object);

                    }
                });
        Bundle parameters = new Bundle();
        parameters.putString("fields", "id,name,link,location");
        request.setParameters(parameters);
        request.executeAsync();

    }
}
