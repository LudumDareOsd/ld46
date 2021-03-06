﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	private List<GameObject> sources = new List<GameObject>();
	public static AudioController instance;

	public void Awake()
	{
		instance = this;
	}

	public AudioSource PlaySingle(AudioClip clip, float volume)
	{
		var audioSrc = GetSource().GetComponent<AudioSource>();
		audioSrc.clip = clip;
		audioSrc.volume = volume;
		audioSrc.spatialBlend = 0;
		audioSrc.dopplerLevel = 0;
		audioSrc.spread = 0;
		audioSrc.pitch = Random.Range(0.8f, 1.2f);
		audioSrc.Play();

		return audioSrc;
	}

	public AudioSource PlayLooping(AudioClip clip, float volume)
	{
		var audioSrc = GetSource().GetComponent<AudioSource>();
		audioSrc.clip = clip;
		audioSrc.volume = volume;
		audioSrc.spatialBlend = 0;
		audioSrc.dopplerLevel = 0;
		audioSrc.spread = 0;
		audioSrc.loop = true;
		audioSrc.pitch = 1f;
		audioSrc.Play();

		return audioSrc;
	}

	public AudioSource PlaySingleLow(AudioClip clip, float volume)
	{

		var audioSrc = GetSource().GetComponent<AudioSource>();
		audioSrc.clip = clip;
		audioSrc.volume = volume;
		audioSrc.spatialBlend = 0;
		audioSrc.dopplerLevel = 0;
		audioSrc.spread = 0;
		audioSrc.pitch = 0.5f;
		audioSrc.Play();

		return audioSrc;
	}

	public AudioSource PlaySingleHigh(AudioClip clip, float volume)
	{

		var audioSrc = GetSource().GetComponent<AudioSource>();
		audioSrc.clip = clip;
		audioSrc.volume = volume;
		audioSrc.spatialBlend = 0;
		audioSrc.dopplerLevel = 0;
		audioSrc.spread = 0;
		audioSrc.pitch = 1.5f;
		audioSrc.Play();

		return audioSrc;
	}

	public GameObject createSource() {
		var newSource = new GameObject("AudioSource");
		newSource.AddComponent<AudioSource>();

		return newSource;
	}

	private GameObject GetSource()
	{
		var source = sources.Find(it => !it.GetComponent<AudioSource>().isPlaying);

		if (source == null)
		{
			var newSource = new GameObject("AudioSource");
			newSource.AddComponent<AudioSource>();
			source = newSource;
			sources.Add(source);
		}

		return source;
	}
}
