package com.works.forme;

import com.unity3d.player.*;
import android.app.Activity;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.content.res.Configuration;
import android.graphics.PixelFormat;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

import java.io.File;
import java.util.List;

public class UnityPlayerActivity extends Activity
{
	protected UnityPlayer mUnityPlayer; // don't change the name of this variable; referenced from native code
	private BlankFragment bf;
	private Controller con;

	// Setup activity layout
	@Override protected void onCreate (Bundle savedInstanceState)
	{
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		super.onCreate(savedInstanceState);

		getWindow().setFormat(PixelFormat.RGBX_8888); // <--- This makes xperia play happy

		mUnityPlayer = new UnityPlayer(this);
		setContentView(mUnityPlayer);
		mUnityPlayer.requestFocus();
		Model model = Model.Companion.getInstance(getApplicationContext());
		mUnityPlayer.UnitySendMessage("AndroidCommunication","SendFullNameToUnity", model.getFirstname() +" " + model.getSecondname());

	}
	public UnityPlayer getmUnityPlayer(){
		return mUnityPlayer;
	}
	public void changeActivity(){
		getFragmentManager().popBackStack();

		Intent inapp = new Intent(UnityPlayerActivity.this,com.works.forme.InAppPurchase.class);
		startActivity(inapp);

	}


	@Override
	public void startActivityForResult(Intent intent, int requestCode) {
		if (intent == null) {
			intent = new Intent();
		}
		super.startActivityForResult(intent, requestCode);
	}

	// Quit Unity
	@Override protected void onDestroy ()
	{
		mUnityPlayer.quit();
		super.onDestroy();
	}

	// Pause Unity
	@Override protected void onPause()
	{
		super.onPause();
		mUnityPlayer.pause();
	}

	// Resume Unity
	@Override protected void onResume()
	{
		super.onResume();
		con = new Controller();
		mUnityPlayer.resume();
		FragmentManager fm = getFragmentManager();

		bf = new BlankFragment();

		FragmentTransaction transaction = fm.beginTransaction();
		transaction.addToBackStack(BlankFragment.class.getName());
		transaction.replace(android.R.id.content, bf, "CHANGESEEEES");
		transaction.commit();

		boolean items[]  = {false,false,false,false};
		File f = new File("UserBoughtState");
		if (f.exists()) {
			con.loadState();
			items = con.getDidbuyItems();
		}
		for (int i = 0;i<items.length;i++){
			String tmp = String.valueOf(i);
			if (items[i])
				mUnityPlayer.UnitySendMessage("AndroidCommunication","javaMessageIn",tmp + "1");
			else{
				mUnityPlayer.UnitySendMessage("AndroidCommunication","javaMessageIn",tmp + "0");
			}
		}



	}

	// This ensures the layout will be correct.
	@Override public void onConfigurationChanged(Configuration newConfig)
	{
		super.onConfigurationChanged(newConfig);
		mUnityPlayer.configurationChanged(newConfig);
	}

	// Notify Unity of the focus change.
	@Override public void onWindowFocusChanged(boolean hasFocus)
	{
		super.onWindowFocusChanged(hasFocus);
		mUnityPlayer.windowFocusChanged(hasFocus);
	}

	// For some reason the multiple keyevent type is not supported by the ndk.
	// Force event injection by overriding dispatchKeyEvent().
	@Override public boolean dispatchKeyEvent(KeyEvent event)
	{
		if (event.getAction() == KeyEvent.ACTION_MULTIPLE)
			return mUnityPlayer.injectEvent(event);
		return super.dispatchKeyEvent(event);
	}

	// Pass any events not handled by (unfocused) views straight to UnityPlayer
	@Override public boolean onKeyUp(int keyCode, KeyEvent event)     { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onKeyDown(int keyCode, KeyEvent event)   { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onTouchEvent(MotionEvent event)          { return mUnityPlayer.injectEvent(event); }
	/*API12*/ public boolean onGenericMotionEvent(MotionEvent event)  { return mUnityPlayer.injectEvent(event); }
}
