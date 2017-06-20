package com.works.forme;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.Signature;
import android.os.Build;
import android.os.Bundle;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;

import com.google.android.gms.ads.AdListener;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.InterstitialAd;
import com.unity3d.player.UnityPlayer;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

/**
 * Created by normen on 23.05.17.
 */

public class Splashscreen extends Activity {

    private ImageView imgView;
    private InterstitialAd mInterstitialAd;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.splash_screen);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            mInterstitialAd = new InterstitialAd(this);
        }
        mInterstitialAd.setAdUnitId("ca-app-pub-9202887805780186/8991148952");
        mInterstitialAd.loadAd(new AdRequest.Builder().addTestDevice("00B74723240B0E3655D79216720F1ABC").build());
        mInterstitialAd.setAdListener(new AdListener() {
            @Override
            public void onAdClosed() {
                startActivity(new Intent(Splashscreen.this,StartActivity.class));
                mInterstitialAd.loadAd(new AdRequest.Builder().build());

            }
        });

        // Add code to print out the key hash
        try {
            PackageInfo info = getPackageManager().getPackageInfo(
                    "com.f0rceUpdat3.first2dApp",
                    PackageManager.GET_SIGNATURES);
            for (Signature signature : info.signatures) {
                MessageDigest md = MessageDigest.getInstance("SHA");
                md.update(signature.toByteArray());
                Log.d("KeyHash:", Base64.encodeToString(md.digest(), Base64.DEFAULT));
            }
        } catch (PackageManager.NameNotFoundException e) {

        } catch (NoSuchAlgorithmException e) {

        }
        imgView = (ImageView) findViewById(R.id.imageViewer);
        imgView.setImageResource(R.drawable.splashscreenintro);
        imgView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (mInterstitialAd.isLoaded()) {
                    mInterstitialAd.show();
                } else {
                    Log.d("TAG", "The interstitial wasn't loaded yet.");
                }
            }
        });

    }
}
