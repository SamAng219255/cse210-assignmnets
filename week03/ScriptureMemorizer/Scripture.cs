class Scripture {
	private Reference _reference;
	private List<Word> _words;

	private List<int> _shuffle;
	private int _shufflePlace;

	public Scripture(Reference reference, string scripture) {
		_reference = reference;

		_words = new List<Word>();
		List<string> verses = new List<string>(scripture.Split(" "));
		_shuffle = new List<int>();
		int nextInd = 0;
		foreach(string word in verses) {
			_words.Add(new Word(word));
			_shuffle.Add(nextInd);
			nextInd++;
		}

		Random randomGenerator = new Random();
		for(int i = 0; i < _words.Count(); i++) {// Fisher-Yates Shuffle
			int swapInd = randomGenerator.Next(i, _words.Count());

			int carry = _shuffle[swapInd];
			_shuffle[swapInd] = _shuffle[i];
			_shuffle[i] = carry;
		}
		_shufflePlace = 0;
	}

	public string GetDisplayText() {
		string displayText = _reference.GetDisplayText() + ":\n";

		bool firstWord = true;
		foreach(Word word in _words) {
			if(firstWord) {
				firstWord = false;
			}
			else {
				displayText += " ";
			}
			displayText += word.GetDisplayText();
		}

		//displayText += $"\n{_shufflePlace} / {_words.Count()}"; // Debug

		return displayText;
	}

	public void HideRandom(int count) {
		for(int i = 0; i < count; i++) {
			int hideIndex = _shufflePlace + i;
			if(hideIndex >= _words.Count()) {
				break;
			}
			else {
				_words[_shuffle[hideIndex]].Hide();
			}
		}
		_shufflePlace += count;
	}

	public bool hiddenAll() {
		return _shufflePlace >= _words.Count();
	}

	public int GetWordCount() {
		return _words.Count();
	}
}